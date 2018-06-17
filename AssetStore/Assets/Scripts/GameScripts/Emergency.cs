using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Emergency {

    private List<Skill> skills;
    public List<Skill> skillsList;

    public List<Character> enemies;

    public int money;

    private static string[] names;

    static Emergency()
    {
        names = GameObject.FindObjectOfType<DataContainer>().nameFile.text.Split(null);
    }

    public Emergency(int countOfEnemies, int sumOfElementPoint,List<Skill> skillList)
    {
        
        skills = new List<Skill>(skillList);
        enemies = new List<Character>();
        money = sumOfElementPoint * 5;
        skillsList = skillList;
        GenerateRandomEnemies(countOfEnemies, sumOfElementPoint, 50);
        skillsList = skills;
    }

    private void GenerateRandomEnemies(int count, int sumPoints,int hpPoints)
    {
        int actualSumPoint = sumPoints;
        for(int i = 0; i < count; i++)
        {
            var rand = Random.Range(0, actualSumPoint);
            actualSumPoint -= rand;
            enemies.Add(GenerateCharacter(rand, hpPoints));
            ClearList();
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
            Name = GetRandomName(),
            skillsPart1 = skilL1,
            skillsPart2 = skilL2
        };

        return enemy;
    }

    private string GetRandomName()
    {
        return names[Random.Range(0, names.Length - 1)] + " " + names[Random.Range(0, names.Length - 1)];
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

        for(int i = 0; i < Random.Range(1, 5); i++)
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

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach(var enemy in enemies)
        {
            stringBuilder.AppendLine(enemy.Name);
            stringBuilder.AppendLine(enemy.GetDescription());
        }
        return stringBuilder.ToString();
    }

    private void ClearList()
    {
        skillsList = new List<Skill>(skills);
    }
	
}
