﻿using System;

// 2차원 좌표를 나타내는 클래스
public class Location2D
{
    // 행 (가로 좌표)
    public int X { get; private set; }
    // 열 (세로 좌표)
    public int Y { get; private set; }

    public Location2D(int row = 0, int column = 0)
    {
        X = row;
        Y = column;
    }
}
