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
    class TrueRoss : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Ross Rifle");
            Tooltip.SetDefault("'Invoke the Spirit of the Wind.'");
        }

        public override void SetDefaults()
        {
            Item.damage = 60;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 66;
            Item.height = 16;
            Item.useTime = 3;
            Item.useAnimation = 14;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 1f;
            Item.value = 200000;
            Item.reuseDelay = 14;
            Item.consumeAmmoOnLastShotOnly = true;
            Item.rare = ItemRarityID.Lime;
            Item.UseSound = new SoundStyle($"{nameof(Mod1)}/Sounds/Item/RossBurst");
            Item.autoReuse = true;
            Item.shoot = 10;
            Item.shootSpeed = 40f;
            Item.useAmmo = AmmoID.Bullet;
        }
		
		public override void HoldItem(Player player)
        {
            player.scope = true;
           
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            player.AddBuff(ModContent.BuffType<Buffs.RossBuff>(), 300);
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Ross>());
            recipe.AddIngredient(ItemID.EyeoftheGolem);
            recipe.AddIngredient(ItemID.HallowedBar, 15);
            recipe.AddTile(ModContent.TileType<GunsmithingTableTile>());
            recipe.Register();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, 0);
        }

        

        /*public override void OnConsumeAmmo(Player player)
        {
            player.AddBuff(ModContent.BuffType<Buffs.RossBuff>(), 300);
        }*/

        /*public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2) // Right Click function
            {
                item.shoot = 10; //10 is the id of bullets
            }
            else // Default Left Click
            {
                Player.scope = true;
            }
            return base.CanUseItem(player);
        }*/

       

    }
}