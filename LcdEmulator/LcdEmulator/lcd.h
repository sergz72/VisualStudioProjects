#ifndef _LCD_H_
#define _LCD_H_

#include "font.h"

typedef struct {
  unsigned short left, top, right, bottom;
  unsigned int textColor, bkColor;
  unsigned short cursorX, cursorY, cursor_enabled, cursor_state;
  const FONT_INFO *font;
} DC;

API void LcdInit(const FONT_INFO *sysfont);
API unsigned int LcdDrawText(DC *dc, unsigned int column, unsigned int row, char *text);
API unsigned int LcdDrawTextCenter(DC *dc, unsigned int column, unsigned int row, unsigned int width, char *text);
API unsigned int LcdDrawTextRight(DC *dc, unsigned int column, unsigned int row, unsigned int width, char *text);
API void LcdClearDC(DC *dc);
API void LcdPutChar(DC *dc, char c);
API void LcdBS(DC *dc);
API void LcdRectFill(DC *dc, unsigned int column, unsigned int row, unsigned int dx, unsigned int dy, unsigned int color);
API void LcdRectangle(DC *dc, unsigned int column, unsigned int row, unsigned int dx, unsigned int dy, unsigned int color, unsigned int PenWidth);
API void LcdScroll(DC *dc, short count);
API void LcdCursorToggle(void);
API void LcdCursorEnable(DC *dc, short enable);
API void LcdPixelDraw(DC *dc, unsigned int lX, unsigned int lY, unsigned int Value);
API void LcdLineDraw(DC *dc, unsigned int X1, unsigned int Y1, unsigned int X2, unsigned int Y2, unsigned int Value, unsigned int PenWidth);
API void LcdLineDrawH(DC *dc, unsigned int lX1, unsigned int lX2, unsigned int lY, unsigned int Value);
API void LcdLineDrawV(DC *dc, unsigned int lX, unsigned int lY1, unsigned int lY2, unsigned int Value);
API unsigned int LcdColorTranslate(int R, int G, int B);
API void LcdInitDC(DC *dc, unsigned short left, unsigned short top, unsigned short width, unsigned short height,
               unsigned int textColor, unsigned int bkColor, const FONT_INFO *font);
API void LcdSetFont(DC *dc, const FONT_INFO *font);
API void LcdSetTextColor(DC *dc, unsigned int textColor);
API void LcdSetBkColor(DC *dc, unsigned int bkColor);
API void LcdSetCursorDC(DC *dc);
API void LcdPutString(DC *dc, const char *s);
API void LcdPrintf(DC *dc, const char *format, ...);
unsigned int lcd_prepare_data_buffer(unsigned int line, char *text, const FONT_INFO *f, unsigned int textColor, unsigned int bkColor);
API int LcdIsPointVisible(DC *dc, unsigned int x, unsigned int y);

#define LcdGetWidth(dc) ((dc)->right - (dc)->left + 1)
#define LcdGetHeight(dc) ((dc)->bottom - (dc)->top + 1)

extern API const unsigned int white_color, black_color;
extern API DC screenDC, *cursorDC, *topDC;
extern unsigned int *display_data_buffer;

#endif /*_LCD_H_*/
