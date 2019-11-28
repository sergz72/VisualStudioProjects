#define PROJECT_EXPORTS
#include "display.h"
#include <process.h>
#include "lcd_buffered.h"
#include "ts_func.h"

#define GD_DT_LEFT 0
#define GD_DT_CENTER 1
#define GD_DT_RIGHT 2

HWND hWnd;
HINSTANCE hInst;
LPCWSTR ClassName = L"lcd_window";

static int **lcd_data, lcd_buffered;
static unsigned int _ZOOM_;

API unsigned int LCD_WIDTH, LCD_HEIGHT, quit_signal;

API const unsigned int white_color = RGB(255, 255, 255);
API const unsigned int black_color = RGB(0, 0, 0);

API DC screenDC;
API DC *cursorDC;
API DC *topDC;

unsigned int *display_data_buffer;

void (*timerProc)(void);
unsigned int timerInterval;

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

//
//   FUNCTION: RegisterClass()
//
//   PURPOSE: Register window class.
//
static BOOL MyRegisterClass()
{
	WNDCLASSEX wcex;

	if (GetClassInfoEx(hInst, ClassName, &wcex))
		return TRUE;

	wcex.cbSize         = sizeof(WNDCLASSEX);

	wcex.style			    = 0; CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc  	= WndProc;
	wcex.cbClsExtra	  	= 0;
	wcex.cbWndExtra	  	= 0;
	wcex.hInstance	  	= hInst;
	wcex.hIcon			    = NULL;
	wcex.hCursor		    = LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground	= (HBRUSH)(COLOR_WINDOW+1);
	wcex.lpszMenuName	  = NULL;
	wcex.hIconSm		    = NULL;
	wcex.lpszClassName	= ClassName;

	return RegisterClassEx(&wcex);

  return TRUE;
}

void WindowThreadProc( void *params ) 
{ 
  MSG msg; 
  BOOL bRet;
  int WH = (int)params;
  RECT r;

  r.top = r.left = 0;
  r.right = (WH >> 16)*_ZOOM_;
  r.bottom = (WH & 0xFFFF)*_ZOOM_;
  AdjustWindowRect(&r, WS_OVERLAPPEDWINDOW, FALSE);

  hWnd = CreateWindow(ClassName, L"LCD Emulator", WS_OVERLAPPEDWINDOW,
                      CW_USEDEFAULT, 0, r.right - r.left + 1, r.bottom - r.top + 1, NULL, NULL, hInst, NULL);

  ShowWindow(hWnd, SW_SHOW);
  UpdateWindow(hWnd);

  // message loop to process user input 

  while ((bRet = GetMessage(&msg, NULL, 0, 0)) != 0) 
  { 
    if (bRet == -1)
  	  return;
    else if (!IsWindow(hWnd) || !IsDialogMessage(hWnd, &msg)) 
    { 
      TranslateMessage(&msg); 
      DispatchMessage(&msg); 
    }
  }

  quit_signal = 1;
} 

int DisplayInit(int W, int H, int zoom, int _lcd_buffered, void (*_timerProc)(void), unsigned int _timerInterval)
{
  int i, sz;

  timerProc = _timerProc;
  timerInterval = _timerInterval;
  lcd_buffered = _lcd_buffered;

  quit_signal = 0;

  hInst = GetModuleHandle(NULL);

  if (!MyRegisterClass())
    return FALSE;

  LCD_WIDTH = W;
  LCD_HEIGHT = H;
  _ZOOM_ = zoom;

  lcd_data = (int**)malloc(sizeof(int) * W);
  sz = sizeof(int) * H;
  for (i = 0; i < W; i++)
    lcd_data[i] = (int*)malloc(sz);

  display_data_buffer = malloc(sizeof(int) * LCD_WIDTH);

  cursorDC = topDC = NULL;

  W  = (W << 16) | H;
  return _beginthread(WindowThreadProc, 0, (void*)W) == -1L ? FALSE : TRUE;
}

//  FUNCTION: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  PURPOSE:  Processes messages for the main window.
//
//  WM_COMMAND	- process the application menu
//  WM_PAINT	- Paint the main window
//  WM_DESTROY	- post a quit message and return
//
//
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
  HDC hDC;
  PAINTSTRUCT ps;
  RECT rcClient;
  HBITMAP hbm;
  HBRUSH hbr;
  RECT rc;
  unsigned int x, y, color;
  HDC memDC;

	switch (message)
	{
    case WM_CREATE:
      if (timerProc != NULL)
      {
        SetTimer(hWnd,             // handle to main window 
                 0,                // timer identifier 
                 timerInterval,    // interval 
                 (TIMERPROC)NULL); // no timer callback
      }
      break;
  	case WM_DESTROY:
      if (timerProc != NULL)
        KillTimer(hWnd, 0);
      PostQuitMessage(0);
		  break;
    case WM_LBUTTONDOWN:
      touch_pos.x = LOWORD(lParam) / _ZOOM_;
      touch_pos.y = HIWORD(lParam) / _ZOOM_;
    case WM_PAINT:
      GetClientRect(hWnd, &rcClient);
      hDC = BeginPaint(hWnd, &ps);
      memDC = CreateCompatibleDC(hDC);
      hbm = CreateCompatibleBitmap(hDC, rcClient.right - rcClient.left + 1, rcClient.bottom - rcClient.top + 1);
      SelectObject(memDC, hbm);
      hbr = CreateSolidBrush(RGB(0, 0, 0));
      FillRect(memDC, &rcClient, hbr);
      DeleteObject(hbr);
      for (y = 0; y < LCD_HEIGHT; y++)
      {
        rc.top  = y * _ZOOM_;
        rc.bottom = rc.top  + _ZOOM_;
        for (x = 0; x < LCD_WIDTH; x++)
        {
          color = lcd_data[x][y];
          if (color != RGB(0, 0, 0))
          {
            rc.left  = x * _ZOOM_;
            rc.right = rc.left + _ZOOM_;
            hbr = CreateSolidBrush(color);
            FillRect(memDC, &rc, hbr);
            DeleteObject(hbr);
          }
        }
      }
      BitBlt(hDC, 0, 0, rcClient.right - rcClient.left + 1, rcClient.bottom - rcClient.top + 1, memDC, 0, 0, SRCCOPY);
      DeleteDC(memDC);
      DeleteObject(hbm);
      EndPaint(hWnd, &ps);
      break;
    case WM_TIMER:
      if (timerProc != NULL)
        timerProc();
      break;
    default:
		  return DefWindowProc(hWnd, message, wParam, lParam);
	}

	return 0;
}

void LcdInit(const FONT_INFO *sysfont)
{
  cursorDC = NULL;

  LcdInitDC(&screenDC, 0, 0, LCD_WIDTH, LCD_HEIGHT, white_color, black_color, sysfont);

  LcdClearDC(NULL);
}

unsigned int lcd_prepare_data_buffer(unsigned int line, char *text, const FONT_INFO *f, unsigned int textColor, unsigned int bkColor)
{
  unsigned int width = 0, w, n;
  unsigned int color;
  const FONT_CHAR_INFO *fci;
  unsigned char spacing = f->character_spacing;
  char c;
  unsigned int *buffer = display_data_buffer;
  unsigned char cc;
  const unsigned char *ccc;

  while ((c = *text++) != 0)
  {
    fci = FontGetChar(c, f);
    if (!fci)
      continue;
    w = fci->char_width;
    width += w + spacing;
    ccc = f->char_bitmaps + fci->char_offset + line * (w & 7 ? (w >> 3) + 1 : w >> 3);
    n = 0;
    cc = *ccc;
    while (w--)
    {
      if (cc & 0x80)
        color = textColor;
      else
        color = bkColor;

      *buffer++ = color;

      cc <<= 1;
      n++;
      if (n % 8 == 0)
        cc = *(++ccc);
    }

    for (w = 0; w < spacing; w++)
      *buffer++ = bkColor;
  }

  return width;
}

void LcdInitDC(DC *dc, unsigned short left, unsigned short top, unsigned short width, unsigned short height,
               unsigned int textColor, unsigned int bkColor, const FONT_INFO *font)
{
  dc->left = left;
  dc->right = dc->left + width - 1;
  dc->top = top;
  dc->bottom = dc->top + height - 1;
  dc->textColor = textColor;
  dc->bkColor = bkColor;
  dc->font = font;
  dc->cursorX = dc->cursorY = dc->cursor_enabled = dc->cursor_state = 0;
}

void LcdSetFont(DC *dc, const FONT_INFO *font)
{
  if (!font)
    return;

  if (!dc)
    dc = &screenDC;

  dc->font = font;
}

void LcdSetTextColor(DC *dc, unsigned int textColor)
{
  if (!dc)
    dc = &screenDC;

  dc->textColor = textColor;
}

void LcdSetBkColor(DC *dc, unsigned int bkColor)
{
  if (!dc)
    dc = &screenDC;

  dc->bkColor = bkColor;
}

void LcdRectangle(DC *dc, unsigned int column, unsigned int row, unsigned int dx, unsigned int dy, unsigned int color, unsigned int PenWidth)
{
  unsigned int i;

  column -= PenWidth / 2;
  row -= PenWidth / 2;

  for (i = 0; i < PenWidth; i++)
  {
    LcdLineDrawH(dc, column, column + dx - 1, row + i, color);
    LcdLineDrawH(dc, column, column + dx - 1, row + dy - 1 + i, color);
    LcdLineDrawV(dc, column + i, row, row + dy - 1, color);
    LcdLineDrawV(dc, column + dx - 1 + i, row, row + dy - 1, color);
  }
}

void LcdClearDC(DC *dc)
{
  if (!dc)
    dc = &screenDC;

  LcdRectFill(dc, 0, 0, LcdGetWidth(dc), LcdGetHeight(dc), dc->bkColor);

  dc->cursorX = dc->cursorY = dc->cursor_state;
}

int LcdIsPointVisible(DC *dc, unsigned int x, unsigned int y)
{
  if (!topDC)
    return 1;

  if (!dc)
    dc = &screenDC;

  if (dc == topDC)
    return 1;

  //  x += dc->left;
  //  y += dc->top;

  if (x >= topDC->left && x <= topDC->right &&
    y >= topDC->top && y <= topDC->bottom)
    return 0;

  return 1;
}

void PixelDraw(DC *dc, int x, int y, int color)
{
  if (!LcdIsPointVisible(dc, x, y))
    return;

  lcd_data[x][y] = color;
}

unsigned int LcdDrawText(DC *dc, unsigned int column, unsigned int row, char *text)
{
  unsigned int line, width, xCount, yCount, i;
  unsigned int *buf;

  if (!dc)
    dc = &screenDC;

  column += dc->left;
  if (column > dc->right)
    return 0;

  row += dc->top;
  if (row > dc->bottom)
    return 0;

  width = xCount = 0;

  yCount = dc->font->char_height;
  if (row + yCount - 1 > dc->bottom)
    yCount = dc->bottom - row + 1;

  for (line = 0; line < yCount; line++)
  {
    width = lcd_prepare_data_buffer(line, text, dc->font, dc->textColor, dc->bkColor);
    if (!xCount)
    {
      xCount = width;
      if (column + xCount - 1 > dc->right)
        xCount = dc->right - column + 1;
    }

    buf = display_data_buffer;

    for(i = 0; i < xCount; i++)
      PixelDraw(dc, column + i, row, *buf++);

    row++;
  }

  if (!lcd_buffered)
    InvalidateRect(hWnd, NULL, FALSE);

  return width;
}

void LcdRectFill(DC *dc, unsigned int column, unsigned int row, unsigned int dx, unsigned int dy, unsigned int color)
{
  int x, dxx;

  if (!dc)
    dc = &screenDC;

  column += dc->left;
  if (column > dc->right)
    return;

  row += dc->top;
  if (row > dc->bottom)
    return;

  while (dy)
  {
    x = column;
    dxx = dx;
    while (dxx)
    {
      PixelDraw(dc, x, row, color);
      dxx--;
      x++;
    }
    dy--;
    row++;
  }

  if (!lcd_buffered)
    InvalidateRect(hWnd, NULL, FALSE);
}

void LcdLineDrawV(DC *dc, unsigned int lX, unsigned int lY1, unsigned int lY2, unsigned int Value)
{
  unsigned int y;

  if (lY2 < lY1)
    return;

  if (!dc)
    dc = &screenDC;

  lX += dc->left;
  if (lX > dc->right)
    return;

  lY1 += dc->top;
  if (lY1 > dc->bottom)
    return;

  lY2 += dc->top;
  if (lY2 > dc->bottom)
    lY2 = dc->bottom;

  for (y = lY1; y <= lY2; y++)
    PixelDraw(dc, lX, y, Value);

  if (!lcd_buffered)
    InvalidateRect(hWnd, NULL, FALSE);
}

void LcdLineDrawH(DC *dc, unsigned int lX1, unsigned int lX2, unsigned int lY, unsigned int Value)
{
  unsigned int x;

  if (lX2 < lX1)
    return;

  if (!dc)
    dc = &screenDC;

  lX1 += dc->left;
  if (lX1 > dc->right)
    return;

  lY += dc->top;
  if (lY > dc->bottom)
    return;

  lX2 += dc->left;
  if (lX2 > dc->right)
    lX2 = dc->right;

  for (x = lX1; x <= lX2; x++)
    PixelDraw(dc, x, lY, Value);

  if (!lcd_buffered)
    InvalidateRect(hWnd, NULL, FALSE);
}

unsigned int LcdDrawTextCenter(DC *dc, unsigned int column, unsigned int row, unsigned int width, char *text)
{
  if (!dc)
    dc = &screenDC;

  column += (width - FontGetWidth(text, dc->font)) / 2;
  return LcdDrawText(dc, column, row, text);
}

unsigned int LcdDrawTextRight(DC *dc, unsigned int column, unsigned int row, unsigned int width, char *text)
{
  if (!dc)
    dc = &screenDC;

  column += width - FontGetWidth(text, dc->font);
  return LcdDrawText(dc, column, row, text);
}

void LcdUpdateRect(DC *dc, unsigned int column, unsigned int row, unsigned int dx, unsigned int dy)
{
  InvalidateRect(hWnd, NULL, FALSE);
}

void LcdUpdateDC(DC *dc)
{
  InvalidateRect(hWnd, NULL, FALSE);
}

unsigned int LcdDrawTextU(DC *dc, unsigned int column, unsigned int row, char *text)
{
  unsigned int w = LcdDrawText(dc, column, row, text);
  InvalidateRect(hWnd, NULL, FALSE);
  return w;
}

unsigned int LcdDrawTextCenterU(DC *dc, unsigned int column, unsigned int row, unsigned int width, char *text)
{
  if (!dc)
    dc = &screenDC;

  column += (width - FontGetWidth(text, dc->font)) / 2;
  return LcdDrawTextU(dc, column, row, text);
}

unsigned int LcdDrawTextRightU(DC *dc, unsigned int column, unsigned int row, unsigned int width, char *text)
{
  if (!dc)
    dc = &screenDC;

  column += width - FontGetWidth(text, dc->font);
  return LcdDrawTextU(dc, column, row, text);
}
