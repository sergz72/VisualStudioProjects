#ifndef _DISPLAY_H
#define _DISPLAY_H

#include <windows.h>

#ifdef PROJECT_EXPORTS
#define API __declspec(dllexport)
#else
#define API __declspec(dllimport)
#endif

extern API unsigned int LCD_WIDTH, LCD_HEIGHT, quit_signal;

API int DisplayInit(int W, int H, int zoom, int _lcd_buffered, void(*_timerProc)(void), unsigned int _timerInterval);

#endif
