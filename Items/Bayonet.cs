using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Mod1.Items
{
    public class Bayonet : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Bayonet");
        }

        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.knockBack = 4;
            Item.value = 300;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 8;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.useStyle = ItemUseStyleID.Rapier;

            Item.shoot = ModContent.ProjectileType<Projectiles.BayonetProjectile>(); // The projectile is what makes a shortsword work
            Item.shootSpeed = 2.1f; // This value bleeds into the behavior of the projectile as velocity, keep that in mind when tweaking values
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronShortsword, 1);
            recipe.AddIngredient(ItemID.Chain, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
