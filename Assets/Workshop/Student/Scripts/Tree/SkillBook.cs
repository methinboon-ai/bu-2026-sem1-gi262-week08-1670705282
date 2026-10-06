using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class SkillBook : MonoBehaviour
{
    public SkillTree attackSkillTree;

    Skill attack;
    Skill fireStorm;
    Skill fireBall;
    Skill fireBlast;
    Skill fireWave;
    Skill fireExplosion;

    public void Start()
    {
        // build skill tree
        // └── Attack
        //     └── FireStorm
        //         ├── FireBlast
        //         └── FireBall
        //             └── FireWave
        //                 └── FireExplosion

        // 1. set the nextSkills for each skill
        attack = new Skill("Attack");
        attack.isAvailable = true;
        fireStorm = new Skill("FireStorm");
        attack.nextSkills.Add(fireStorm);
        fireBlast = new Skill("FireBlast");
        fireStorm.nextSkills.Add(fireBlast);
        fireBall = new Skill("FireBall");
        fireStorm.nextSkills.Add(fireBall);
        fireWave = new Skill("FireWave");
        fireBall.nextSkills.Add(fireWave);
        fireExplosion = new Skill("FireExplosion");
        fireWave.nextSkills.Add(fireExplosion);


        this.attackSkillTree = new SkillTree(attack);
    }

    public void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard != null && keyboard.pKey.wasPressedThisFrame)
        {
            attackSkillTree.rootSkill.PrintSkillTreeHierarchy("");
            // attackSkillTree.rootSkill.PrintSkillTree();
            Debug.Log("====================================");
        }
    }
}

