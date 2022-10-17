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
    class MosinWithBayonet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mosin-Nagant with Bayonet");
            Tooltip.SetDefault("The knife doubles it's value.");
        }

        public override void SetDefaults()
        {
            Item.damage = 70;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 72;
            Item.height = 16;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 5.25f;
            Item.value = 50000;
            Item.rare = ItemRarityID.LightRed;
            Item.autoReuse = true;
            Item.shootSpeed = 28f;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.UseSound = SoundID.Item1;
                Item.DamageType = DamageClass.Melee;
                Item.useTime = 20;
                Item.useAnimation = 20;
                Item.damage = 50;
                Item.shoot = ModContent.ProjectileType<Projectiles.MosinProjectile>();
                return player.ownedProjectileCounts[Item.shoot] < 1;
            }
            else
            {
                Item.damage = 70;
                Item.DamageType = DamageClass.Ranged;
                Item.useTime = 30;
                Item.useAnimation = 30;
                Item.knockBack = 5.25f;
                Item.UseSound = SoundID.Item11;
                Item.shoot = 10;
            }
            return base.CanUseItem(player);
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, 0);
        }
    }
}
