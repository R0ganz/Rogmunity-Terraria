using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.Audio;

namespace Mod1.Items
{
	public class PunkSlimeStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Punk Slime Staff");
			Tooltip.SetDefault("Summons a baby slime to fight for you. Except it's punk... yeah..");
			ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 85;
			Item.knockBack = 3f;
			Item.mana = 10;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.buyPrice(0, 30, 0, 0);
			Item.rare = ItemRarityID.Cyan;

			Item.UseSound = new SoundStyle($"{nameof(Mod1)}/Sounds/Item/PunkSlimeSummonEffect")
			{
				Volume = 0.9f,
				PitchVariance = 1f,
				MaxInstances = 3,
			};

			// These below are needed for a minion weapon
			Item.noMelee = true;
			Item.DamageType = DamageClass.Summon;
			Item.buffType = ModContent.BuffType<Buffs.PunkSlimeBuff>();
			// No buffTime because otherwise the item tooltip would say something like "1 minute duration"
			Item.shoot = ModContent.ProjectileType<Projectiles.Minions.PunkSlimeProjectile>();
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			// Here you can change where the minion is spawned. Most vanilla minions spawn at the cursor position.
			position = Main.MouseWorld;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			// This is needed so the buff that keeps your minion alive and allows you to despawn it properly applies
			player.AddBuff(Item.buffType, 2);

			// Minions have to be spawned manually, then have originalDamage assigned to the damage of the summon item
			var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, Main.myPlayer);
			projectile.originalDamage = Item.damage;

			// Since we spawned the projectile manually already, we do not need the game to spawn it for ourselves anymore, so return false
			return false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SlimeStaff);
			recipe.AddIngredient(ItemID.Ectoplasm, 10);
			recipe.AddIngredient(ItemID.ShroomiteBar, 5);
			recipe.AddIngredient(ItemID.Gel, 999);
			recipe.AddIngredient(ItemID.Stinger, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}


}