﻿using System;

namespace childhood_games_pack.tanks.Utils
{
    public class BaseKillStrategy : ICompTankStrategy
    {
        public DIRECTION GetNewDirection()
        {
            throw new NotImplementedException();
        }

        public bool IsNeedShoot()
        {
            throw new NotImplementedException();
        }
    }
}
