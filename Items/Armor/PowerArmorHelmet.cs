using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod1.Tiles;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.Audio;

namespace Mod1.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class PowerArmorHelmet : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'Terraria Never Changes'");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 32;
			Item.accessory = false;
			Item.defense = 50;
			Item.rare = ItemRarityID.LightRed;
		}

		public override void AddRecipes()
		{
			Recipe pwerarmorhelmet1 = Recipe.Create(ModContent.ItemType<PowerArmorHelmet>(), 1);
			pwerarmorhelmet1.AddIngredient(ItemID.VortexHelmet, 1);
			pwerarmorhelmet1.AddIngredient(ItemID.NebulaHelmet, 1);
			pwerarmorhelmet1.AddIngredient(ItemID.SolarFlareHelmet, 1);
			pwerarmorhelmet1.AddIngredient(ItemID.StardustHelmet, 1);
			pwerarmorhelmet1.AddTile(TileID.Autohammer);
			pwerarmorhelmet1.Register();


		}
	}
}
