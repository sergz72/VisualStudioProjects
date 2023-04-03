#define PROJECT_EXPORTS
#include "ts_func.h"

ts_point touch_pos = { 0, 0 };

ts_point ts_get_touch_pos(void)
{
  return touch_pos;
}
