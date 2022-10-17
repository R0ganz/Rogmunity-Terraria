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

namespace Mod1.Items.Weapons
{
    class Ross : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ross Rifle");
            Tooltip.SetDefault("'Smells like maple syrup.'");
        }

        public override void SetDefaults()
        {
            Item.damage = 25;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 60;
            Item.height = 14;
            Item.useTime = 4;
            Item.useAnimation = 17;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 0;
            Item.value = 50000;
            Item.reuseDelay = 14;
            Item.consumeAmmoOnLastShotOnly = true;
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = new SoundStyle($"{nameof(Mod1)}/Sounds/Item/RossBurst");
            Item.autoReuse = true;
            Item.shoot = 10;
            Item.shootSpeed = 30f;
            Item.useAmmo = AmmoID.Bullet;

        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
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

    }
}
