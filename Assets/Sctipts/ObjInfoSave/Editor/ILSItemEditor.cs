using UnityEngine;
using System.Collections;
using UnityEditor;
[CustomEditor(typeof(ILSItem))]
public class ILSItemEditor : Editor {

    private ILSItem _EditorObj;
    private SerializedObject obj;//序列化物体
    private SerializedProperty _matInfoArray;//序列化属性

    void OnEnable()
    {
        obj = new SerializedObject(target);
        _EditorObj = target as ILSItem;
        _matInfoArray = obj.FindProperty("MatInfoArray");
    }

    public override void OnInspectorGUI()
    {
        obj.Update();
        _EditorObj._type = (E_ILSTYPE)EditorGUILayout.EnumMaskField("选择类型",_EditorObj._type);
        if ((_EditorObj._type&E_ILSTYPE.MatInfo)!=0)
        {
            EditorGUILayout.PropertyField(_matInfoArray,true);
        }
        //结束检查是否有修改
        if (GUI.changed)
        {//提交修改
            obj.ApplyModifiedProperties();
        }
    }
}
