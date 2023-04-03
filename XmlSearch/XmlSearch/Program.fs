open System.Xml
open System

let processAttributes(attribs: XmlAttributeCollection, path: List<String>, name: string) =
  [ for i in 0 .. attribs.Count-1 do yield attribs.Item(i) ]
  |> List.map(fun node -> List.append path [name + "@" + node.Name])

let rec processNodes(nodes: XmlNodeList, path: List<String>) =
  [ for i in 0 .. nodes.Count-1 do yield nodes.Item(i) ]
  |> List.map(fun node -> (node, List.append path [node.Name]))
  |> List.filter(fun (node, _) -> node.Name <> "#text")
  |> List.map(fun (node, p) -> [[p]; (if node.Attributes <> null then processAttributes(node.Attributes, path, node.Name) else []); List.concat(processNodes(node.ChildNodes, p))])
  |> List.concat

let rec listSkip n xs = 
  match (n, xs) with
  | 0, _ -> xs
  | _, [] -> []
  | n, _::xs -> listSkip (n-1) xs

[<EntryPoint>]
let main argv =
  let xdoc = new XmlDocument()
  xdoc.Load(argv.[0])
  let skip = if argv.Length > 1 then argv.[1] |> int else 0
  let filter = if argv.Length > 2 then argv.[2].ToLower() else null
  processNodes(xdoc.ChildNodes, List.empty)
  |> List.concat
  |> List.filter(fun list -> list.Length > skip)
  |> List.map(fun list -> listSkip skip list)
  |> List.map(fun list -> String.concat "." list)
  |> List.filter(fun path -> if filter = null then true else path.ToLower().Contains(filter))
  |> Seq.distinct
  |> Seq.sort
  |> Seq.iter(fun path -> Console.WriteLine(path))
  0
