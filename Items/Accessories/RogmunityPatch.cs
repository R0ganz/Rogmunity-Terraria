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

namespace Mod1.Items.Accessories
{
	[AutoloadEquip(EquipType.Face)]
	public class RogmunityPatch : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("80% increased damage\n"
							 + "Made specifically for Daddy Roganz.\n"
							 + "'A skull with dice for eyes'");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 26;
			Item.accessory = true;
			Item.defense = 100;
			Item.rare = ItemRarityID.LightRed;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			
			player.GetDamage(DamageClass.Generic) += 0.8f;
			
		}

		public override void AddRecipes()
		{
			Recipe rogpatch1 = Recipe.Create(ModContent.ItemType<RogmunityPatch>(), 1);
			rogpatch1.AddIngredient(ItemID.StoneBlock, 5);
			rogpatch1.AddIngredient(ItemID.Bone, 3);
			rogpatch1.AddIngredient(ItemID.GoldCrown, 1);
			rogpatch1.AddTile(TileID.Anvils);
			rogpatch1.Register();

			Recipe rogpatch2 = Recipe.Create(ModContent.ItemType<RogmunityPatch>(), 1);
			rogpatch2.AddIngredient(ItemID.StoneBlock, 5);
			rogpatch2.AddIngredient(ItemID.Bone, 3);
			rogpatch2.AddIngredient(ItemID.PlatinumCrown, 1);
			rogpatch2.AddTile(TileID.Anvils);
			rogpatch2.Register();

		}
	}
}
