using System;
using System.Collections.Generic;
using System.Text;

namespace HW1
{
    public interface IDamageable
    {
        public void TakeDamage(int damage);
    }

    public class Health : IDamageable
    {
        public int Value { get; private set; }

        public void TakeDamage(int damage)
        {
            Value -= damage;
        }
    }

    public class Player : IDamageable
    {
        private Health _health;

        public Player(Health health)
        {
            _health = health;
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }
    }

    public class Weapon
    {
        private int _damage;
        private int _bullets;

        public Weapon(int damage, int bullets)
        {
            _damage = damage;
            _bullets = bullets;
        }

        public void Fire(IDamageable damageable)
        {
            if (_bullets == 0)
                return;

            damageable.TakeDamage(_damage);
            _bullets--;
        }
    }

    public class Bot
    {
        private Weapon _weapon;

        public Bot(Weapon weapon)
        {
            _weapon = weapon;
        }

        public void OnSeePlayer(Player player)
        {
            _weapon.Fire(player);
        }
    }
}
