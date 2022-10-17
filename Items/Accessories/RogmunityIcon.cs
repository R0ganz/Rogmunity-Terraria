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
	public class RogmunityIcon : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("260% increased damage\n"
							 + "Daddy Roganz hungers for more.\n"
							 + "'A great Community brought this together'");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 26;
			Item.accessory = true;
			Item.defense = 180;
			Item.rare = ItemRarityID.Purple;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{

			player.GetDamage(DamageClass.Generic) += 2.6f;

		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<RogmunityPatch>());
			recipe.AddIngredient(ItemID.Prismite, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}