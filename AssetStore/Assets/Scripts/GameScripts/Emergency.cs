using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emergency {

    public List<Skill> skillsList;

    public List<Character> enemies;

    public int money;

    public Emergency(int countOfEnemies, int sumOfElementPoint)
    {
        money = sumOfElementPoint * 5;
        GenerateRandomEnemies(countOfEnemies, sumOfElementPoint, 50);
    }

    private void GenerateRandomEnemies(int count, int sumPoints,int hpPoints)
    {
        int actualSumPoint = sumPoints;
        for(int i = 0; i < count; i++)
        {
            var rand = Random.Range(0, actualSumPoint);
            actualSumPoint -= rand;
            enemies.Add(GenerateCharacter(rand, hpPoints));
        }
    }

    private Character GenerateCharacter(int sumPoints, int hpPoints)
    {
        List<Skill> skillList = new List<Skill>(skillsList);
        var skilL1 = GetSkillList(skillsList);
        var skilL2 = GetRandomIntList(skilL1.Count, sumPoints);

        var enemy = new Character()
        {
            actualHpPoints = hpPoints,
            name = "placeHolder",
            skillsPart1 = skilL1,
            skillsPart2 = skilL2
        };

        return enemy;
    }

    private List<int> GetRandomIntList(int count,int sumPoints)
    {
        int actualSumPoints = sumPoints;

        var result = new List<int>();
        for(int i =0 ; i<count; i++)
        {
            var rand = Random.Range(0, actualSumPoints);
            result.Add(rand);
            actualSumPoints -= rand;
        }

        return result;
    }

    private List<Skill> GetSkillList(List<Skill> list)
    {
        var result = new List<Skill>();

        for(int i = 0; i < Random.Range(1, 3); i++)
        {
            result.Add(GetRandom(list));
        }
        return result;
    }

    private Skill GetRandom(List<Skill> list)
    {
        var skill = list[Random.Range(0, list.Count - 1)];
        list.Remove(skill);
        return skill;
    }
	
}
