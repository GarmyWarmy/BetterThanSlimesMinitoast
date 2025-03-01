﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterThanSlimes.Content.Items.Accessories
{
    public class Kapala : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Localization handled through localization file
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 14;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 1);
            Item.rare = ItemRarityID.Red;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxMinions += 1; // Grants an additional summon slot
            player.statLifeMax2 += 20; // Increases maximum life by 20
            player.GetModPlayer<KapalaPlayer>().kapalaEquipped = true;
        }
    }

    public class KapalaPlayer : ModPlayer
    {
        public bool kapalaEquipped = false;
        public bool kapalaHeart = false; // New property to mark Kapala hearts

        public override void ResetEffects()
        {
            kapalaEquipped = false;
            kapalaHeart = false;
        }
    }

    public class ExampleGlobalNPC : GlobalNPC
    {
        public override void OnKill(NPC npc)
        {
            if (Main.LocalPlayer.GetModPlayer<KapalaPlayer>().kapalaEquipped &&
                npc.life <= 0 && !npc.friendly && npc.catchItem <= 0 && npc.type != NPCID.Bee)
            {
                // 1/4 chance to drop a heart
                if (Main.rand.NextBool(4))
                {
                    Main.LocalPlayer.GetModPlayer<KapalaPlayer>().kapalaHeart = true; // Set the flag
                    Item.NewItem(npc.GetSource_Loot(), npc.getRect(), ItemID.Heart);
                    Main.LocalPlayer.GetModPlayer<KapalaPlayer>().kapalaHeart = false; // Reset the flag
                }
            }
        }
    }
}
