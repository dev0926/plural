﻿/*
 * Huyn.PluralNet
 * Author  Rudy Huyn (6Studio)
 * License MIT / http://bit.ly/mit-license
 * 
 * Version 1.00
 */
using Huyn.PluralNet.Utils;
using Huyn.PluralNet.Interfaces;

namespace Huyn.PluralNet.Providers
{
    public class BreizhProvider : IPluralProvider
    {
        public PluralTypeEnum ComputePlural(decimal n)
        {
            if (n.IsInt())
            {
                var mod10 = n % 10;
                var mod100 = n % 100;
                if (mod10 == 1 && mod100 != 11 && mod100 != 71 && mod100 != 91)
                {
                    return PluralTypeEnum.ONE;
                }
                if (mod10 == 2 && mod100 != 12 && mod100 != 72 && mod100 != 92)
                {
                    return PluralTypeEnum.TWO;
                }
                var diffMod = mod100 - mod10;
                if ((mod10 == 3 || mod10 == 4 || mod10 == 9) && diffMod != 10 && diffMod != 70 && diffMod != 90)
                {
                    return PluralTypeEnum.FEW;
                }
                if (n != 0 && n % 1000000 == 0)
                    return PluralTypeEnum.MANY;
            }
            return PluralTypeEnum.OTHER;
        }
    }
}
