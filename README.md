## ILS场景序列化
[文档](http://note.youdao.com/noteshare?id=68728237445a12c97b77cf6139824b19)
### ObjID
挂载`ObjID`,将会自动分配一个id

### ILSItem
对需要序列化保存和恢复信息的物体挂载`ILSItem`  

 ![image](E9810ACB75A64E0A847015D9A85FCB8D)

1. **TransformInfo**：保存物体位置、旋转、缩放、Active信息
2. **Parent**：保存物体父物体信息
3. **MatInfo**：保存Material信息  
     ![image](3567508969214ADD9C8AA0A3B844F955)
    + **MatID**:该material在`Renderer-Materials`中的下标
    + **PropertyType**：支持两种类型
    + **PropertyName**：要保存的属性的名称
4. **Reflection**：反射保存类中的字段或属性  
    ![image](F003D69CF8694522BE2AB794F5B401AF)
    * **ClassNmae**：类名
    * **FieldName**：字段或属性的名字
    * **ClassType**：支持的几种类型
### 序列化和反序列化
1. **序列化**：调用`ILSManager.SaveInfo(key)`将场景中所有挂载`ILSItem`的物体序列化指定信息，存入字典中
2. **反序列化**：调用` ILSManager.LoadStepInfo(key)`，反序列化恢复场景信息
### Tools  
![image](5917E418E22C478597124FC480356A00)
1. **CleanDic**:清空当前中存储的所有ID信息
2. **IDDic2Json**：将当前存储的所有ID信息序列化保存到text中
3. **SearchID**：打开一个查找面板  
    ![image](958F6A1DCCD349F492BA80C7E784B29D)



    
    
             
