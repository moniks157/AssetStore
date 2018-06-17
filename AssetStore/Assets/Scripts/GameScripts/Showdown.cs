using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Showdown  {

    public static bool Battle(List<Character> characterList, List<Character> enemyList)
    {
        Queue<Character> characters = new Queue<Character>(characterList);
        Queue<Character> enemies = new Queue<Character>(enemyList);

        while (characters.Count != 0 && enemies.Count != 0)
        {
            var character = characters.Dequeue();
            var enemy = enemies.Dequeue();

            Attack(character, enemy);
            Attack(enemy, character);

            if (character.actualHpPoints > 0)
                characters.Enqueue(character);

            if (enemy.actualHpPoints > 0)
                enemies.Enqueue(enemy);
        }

        foreach(var v in characters)
        {
            if (v.actualHpPoints > 0)
                v.actualHpPoints = v.hpPoints;
        }

        if (enemies.Count == 0)
            return true;
        return false;
    }

    private static void Attack(Character attacker, Character defender)
    {
        if (defender.PrimarySkill.weekFor == attacker.PrimarySkill)
        {
            defender.actualHpPoints -= (int)(attacker.SkillValueSum * 1.5);
        }
        else
        {
            defender.actualHpPoints -= attacker.SkillValueSum;
        }
    }

}
