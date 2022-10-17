﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Mod1.Items.Placeables
{
    public class GunsmithingTable : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gunsmithing Table");
            Tooltip.SetDefault("A table for all your gunsmithing needs.");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 24;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 150000;
            Item.createTile = ModContent.TileType<Tiles.GunsmithingTableTile>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HeavyWorkBench);
            recipe.AddIngredient(ItemID.IllegalGunParts, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
