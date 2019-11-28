#include "board.h"
#include "ui.h"
#include <lcd_ks0108_buffered.h>
#include <fonts/font8_2.h>
#include <fonts/font5.h>

volatile SensorData in, out;
volatile unsigned int frequency;
volatile unsigned int duty;

void UI_Init(void)
{
  LcdRectangle(0, 10, 48, 40, 1, 1);
  LcdRectangle(LCD_WIDTH - 48, 10, 48, 40, 1, 1);
  LcdDrawText(16, 7, "IN", &courierNew8ptFontInfo, 0);
  LcdDrawText(LCD_WIDTH - 35, 7, "OUT", &courierNew8ptFontInfo, 0);

  LcdDrawText(2, 17, " 0.0V", &courierNew8ptFontInfo, 0);
  LcdDrawText(2, 27, "0.00A", &courierNew8ptFontInfo, 0);
  LcdDrawText(2, 37, " 0.0W", &courierNew8ptFontInfo, 0);

  LcdDrawText(LCD_WIDTH - 46, 17, " 0.0V", &courierNew8ptFontInfo, 0);
  LcdDrawText(LCD_WIDTH - 46, 27, "0.00A", &courierNew8ptFontInfo, 0);
  LcdDrawText(LCD_WIDTH - 46, 37, " 0.0W", &courierNew8ptFontInfo, 0);

  LcdDrawText(55, 2, "EFF", &fiveBySevenFontInfo, 0);
  LcdDrawText(55, 12, " 0%", &fiveBySevenFontInfo, 0);

  LcdDrawText(51, 22, "Freq", &fiveBySevenFontInfo, 0);
  LcdDrawText(51, 32, "  0k", &fiveBySevenFontInfo, 0);

  LcdDrawText(51, 42, "Duty", &fiveBySevenFontInfo, 0);
  LcdDrawText(55, 52, " 0%", &fiveBySevenFontInfo, 0);
}

void UI_Update()
{
  int powerin, powerout;

  LcdPrintf("%2d.%d", 2, 17, &courierNew8ptFontInfo, 0, in.voltage / 10, in.voltage % 10);
  LcdPrintf("%d.%02d", 2, 27, &courierNew8ptFontInfo, 0, in.current / 100, in.current % 100);
  powerin = in.voltage * in.current / 100;
  LcdPrintf("%2d.%d", 2, 37, &courierNew8ptFontInfo, 0, powerin / 10, powerin % 10);

  LcdPrintf("%2d.%d", LCD_WIDTH - 46, 17, &courierNew8ptFontInfo, 0, out.voltage / 10, out.voltage % 10);
  LcdPrintf("%d.%02d", LCD_WIDTH - 46, 27, &courierNew8ptFontInfo, 0, out.current / 100, out.current % 100);
  powerout = out.voltage * out.current / 100;
  LcdPrintf("%2d.%d", LCD_WIDTH - 46, 37, &courierNew8ptFontInfo, 0, powerout / 10, powerout % 10);

  LcdPrintf("%2d", 55, 12, &fiveBySevenFontInfo, 0, powerout * 100 / powerin);
  LcdPrintf("%3d", 51, 32, &fiveBySevenFontInfo, 0, frequency);
  LcdPrintf("%2d", 55, 52, &fiveBySevenFontInfo, 0, duty);

  LcdUpdate();
}
