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

namespace Mod1.Items.Weapons
{
    class TrueMosin : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Mosin-Nagant");
            Tooltip.SetDefault("'You're in the Bullets Way.'");
        }

        public override void SetDefaults()
        {
            Item.damage = 210;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 64;
            Item.height = 18;
            Item.useTime = 26;
            Item.useAnimation = 26;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 8f;
            Item.value = 50000;
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.shoot = 10;
            Item.shootSpeed = 28f;
            Item.useAmmo = AmmoID.Bullet;
            Item.crit = 75;

        }
				
				public override void HoldItem(Player player)
        {
            player.scope = true;
           
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Mosin>());
            recipe.AddIngredient(ItemID.EyeoftheGolem);
            recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddTile(ModContent.TileType<GunsmithingTableTile>());
            recipe.Register();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, 0);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
        }
    
    }
}
