#include "roguelib.h"
#include <curses.h>

namespace roguelib
{
	class Main
	{
	public:
		Main()
		{
			initscr();
			raw();
			keypad(stdscr, true);
			noecho();
			start_color();
		}

		~Main()
		{
			endwin();
		}

		int ReadKey()
		{
			return getch();
		}

		int ParseColor(const char color)
		{
			if (color == ' ')
				return 0;
			return COLOR_PAIR(color);
		}

		void Draw(const char* chars, const char* colors, const int cols, const int rows, const std::string& message)
		{
			clear();
			for (int j = 0; j < rows; ++j)
			{
				move(j, 0);
				for (int i = 0; i < cols; ++i)
				{
					int attr = ParseColor(colors[i + j * (cols + 1)]);
					addch(chars[i + j * (cols + 1)] | attr);
				}
			}
			move(rows, 0);
			printw(message.c_str());
			refresh();
		}

		void DrawBar(const int x, const int y, const int length, const char fill, const char color, const bool vertical)
		{
			int attr = ParseColor(color);
			attron(attr);
			for (int i = 0; i < length; ++i)
			{
				if (vertical)
					move(y + i, x);
				else
					move(y, x + i);
				addch(fill);
			}
			attroff(attr);
			refresh();
		}
	};

	static Main instance;

	int ReadKey() { return instance.ReadKey(); }
	void Draw(const void* chars, const void* colors, const int cols, const int rows, const std::string& message) { return instance.Draw(reinterpret_cast<const char*>(chars), reinterpret_cast<const char*>(colors), cols, rows, message); }
	void DrawHorizontalBar(const int x, const int y, const int length, const char fill, const char color) { return instance.DrawBar(x, y, length, fill, color, false); }
	void DrawVerticalBar(const int x, const int y, const int length, const char fill, const char color) { return instance.DrawBar(x, y, length, fill, color, true); }

}
