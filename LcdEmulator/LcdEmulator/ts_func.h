#ifndef _TS_FUNC_H
#define _TS_FUNC_H

#include "display.h"

typedef struct {
  int x, y;
} ts_point;

typedef struct {
  double alpha_x, beta_x, delta_x;
  double alpha_y, beta_y, delta_y;
} ts_calibration_data;

API extern ts_point touch_pos;

API ts_point ts_get_touch_pos(void);

#endif
