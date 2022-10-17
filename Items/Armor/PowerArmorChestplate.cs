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
	[AutoloadEquip(EquipType.Body)]
	public class PowerArmorChestplate : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'Terraria Never Changes'");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 20;
			Item.accessory = false;
			Item.defense = 50;
			Item.rare = ItemRarityID.LightRed;
		}
		
		public override void AddRecipes()
		{
			Recipe pwerarmorhelmet1 = Recipe.Create(ModContent.ItemType<PowerArmorChestplate>(), 1);
			pwerarmorhelmet1.AddIngredient(ItemID.VortexBreastplate, 1);
			pwerarmorhelmet1.AddIngredient(ItemID.NebulaBreastplate, 1);
			pwerarmorhelmet1.AddIngredient(ItemID.SolarFlareBreastplate, 1);
			pwerarmorhelmet1.AddIngredient(ItemID.StardustBreastplate, 1);
			pwerarmorhelmet1.AddTile(TileID.Autohammer);
			pwerarmorhelmet1.Register();


		}
	}
}
