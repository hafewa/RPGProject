﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillItem : MonoBehaviour
{
    public int id;
    private SkillInfo info;
    private UISprite iconname_sprite;
    private UILabel name_label;
    private UILabel applytype_label;
    private UILabel des_label;
    private UILabel mp_label;
    private GameObject icon_mask;

    private void Awake()
    {
    }

    void InitProperty()
    {
        iconname_sprite = transform.Find("icon_name").GetComponent<UISprite>();
        name_label = transform.Find("property/name_bg/name").GetComponent<UILabel>();
        applytype_label = transform.Find("property/applytype_bg/applytype").GetComponent<UILabel>();
        des_label = transform.Find("property/des_bg/des").GetComponent<UILabel>();
        mp_label = transform.Find("property/mp_bg/mp").GetComponent<UILabel>();
        icon_mask = transform.Find("icon_mask").gameObject;
        icon_mask.SetActive(false);
    }

    // 通过调用该方法来更新显示
    public void SetId(int id)
    {
        InitProperty();
        this.id = id;
        info = SkillsInfo._instance.GetSkillInfoById(id);
        iconname_sprite.spriteName = info.icon_name;
        name_label.text = info.name;
        switch (info.applyType)
        {
            case ApplyType.Passive:
                applytype_label.text = "增益";
                break;
            case ApplyType.Buff:
                applytype_label.text = "增强";
                break;
            case ApplyType.SingleTarget:
                applytype_label.text = "单个目标";
                break;
            case ApplyType.MultiTarget:
                applytype_label.text = "多个目标";
                break;
        }
        des_label.text = info.des;
        mp_label.text = info.mp.ToString();
    }

    public void UpdateShow(int level)
    {
        // 技能可用
        if (info.level <= level)
        {
            icon_mask.SetActive(false);
            iconname_sprite.GetComponent<SkillItemIcon>().enabled = true;
        }
        else
        {
            icon_mask.SetActive(true);
            // 不可拖拽
            iconname_sprite.GetComponent<SkillItemIcon>().enabled = false;
        }
    }
}
