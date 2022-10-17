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
    class Mosin : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mosin-Nagant");
            Tooltip.SetDefault("'You see, Artyom, when using Mosin, Enemy will not fight you, because you are no threat.'");
        }

        public override void SetDefaults()
        {
            Item.damage = 70;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 62;
            Item.height = 16;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 5.25f;
            Item.value = 50000;
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.shoot = 10;
            Item.shootSpeed = 28f;
            Item.useAmmo = AmmoID.Bullet;


        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Musket);
            recipe.AddIngredient(ItemID.RangerEmblem);
            recipe.AddIngredient(ItemID.SoulofNight, 15);
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
