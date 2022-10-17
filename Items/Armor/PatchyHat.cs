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
	public class PatchyHat : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'A man has to have his priorities'");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 30;
			Item.accessory = true;
			Item.defense = 2;
			Item.rare = ItemRarityID.LightRed;
		}

		public override void AddRecipes()
		{
			Recipe patchhat1 = Recipe.Create(ModContent.ItemType<PatchyHat>(), 1);
			patchhat1.AddIngredient(ItemID.TatteredCloth, 5);
			patchhat1.AddTile(TileID.HeavyWorkBench);
			patchhat1.Register();


		}
	}
}
