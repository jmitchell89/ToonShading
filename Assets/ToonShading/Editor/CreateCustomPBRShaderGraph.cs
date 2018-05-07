using System.IO;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEditor.ShaderGraph;

public class CreateCustomPBRShaderGraph : EndNameEditAction
{
    [MenuItem("Assets/Create/Shader/Toon PBR", false, 208)]
    public static void CreateMaterialGraph()
    {
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, CreateInstance<CreateCustomPBRShaderGraph>(),
            "New Shader Graph.ShaderGraph", null, null);
    }

    public override void Action(int instanceId, string pathName, string resourceFile)
    {
        var graph = new MaterialGraph();
        graph.AddNode(new CustomPBRNode());
        File.WriteAllText(pathName, EditorJsonUtility.ToJson(graph));
        AssetDatabase.Refresh();
    }
}