using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public SkillBase[] Skills;

    void Start()
    {
        //tüm yetenekleri baþlat
        foreach (var skill in Skills)
        {
            skill.Initialize();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) UseSkill(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) UseSkill(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) UseSkill(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) UseSkill(3);
        if (Input.GetKeyDown(KeyCode.Alpha5)) UseSkill(4);
    }

    void UseSkill(int index)
    {
        if (index < 0 || index >= Skills.Length) return;

        SkillBase skill = Skills[index];
        skill.Activate(gameObject); 
    }
}
