#pragma once

#include <Windows.h>

#define LCD_WIDTH 128
#define LCD_HEIGHT 64
#define LCD_SCALE 3
#define LCD_TEST
#define LCD_CS1 1
#define LCD_CS2 2
#define LCD_CONTROLLER_COUNT 2
#define LCD_CONTROLLER_AREA 64
#define DRAW_TEXT_MAX 10
#define LCD_PRINTF_BUFFER_LENGTH 10

typedef struct {
  int voltage;
  int current;
} SensorData;

extern volatile SensorData in, out;
extern volatile unsigned int frequency;
extern volatile unsigned int duty;

extern HWND hWindow;

void LcdPaint(HDC);
