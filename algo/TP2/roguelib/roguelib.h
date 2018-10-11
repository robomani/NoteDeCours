#ifndef _ROGUE_LIB_H_
#define _ROGUE_LIB_H_

#include <string>

namespace roguelib
{
	int ReadKey();
	void Draw(const void* chars, const void* colors, const int cols, const int rows, const std::string& message = "");
	void DrawHorizontalBar(const int x, const int y, const int length, const char fill, const char color);
	void DrawVerticalBar(const int x, const int y, const int length, const char fill, const char color);
}

#endif /* _ROGUE_LIB_MAIN_H_ */
