﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace BetterThanSlimes.Common.VanillaItemChanges.Tools
{
    // This file shows a very simple example of a GlobalItem class. GlobalItem hooks are called on all items in the game and are suitable for sweeping changes like 
    // adding additional data to all items in the game. Here we simply adjust the damage of the Copper Shortsword item, as it is simple to understand. 
    // See other GlobalItem classes in ExampleMod to see other ways that GlobalItem can be used.
    public class CopperPickaxe : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.CopperPickaxe)
            { // Here we make sure to only change Copper Shortsword by checking item.type in an if statement
                item.tileBoost = 1;
            }
        }
    }
}