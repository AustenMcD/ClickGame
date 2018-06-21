// Learn more about F# at http://fsharp.org

open System
open Terminal.Gui
open NStack

let ustr (x:string) = ustring.Make(x)

let stop = Action Application.RequestStop

let quit() =
    if MessageBox.Query (50, 7, "Quit", "Are you sure you want to quit?", "Yes", "No") =0 then
        Application.Top.Running <- false

let buildMenu() =
    new MenuBar ([|
        new MenuBarItem (ustr ("Menu"), 
            [| MenuItem (ustr ("_Quit"), null, System.Action quit) 
             |])|])

let increment (x : byref<_>) =
    x <- x + 1
    ()
    



[<EntryPoint>]
let main argv =
    Application.Init ()
    let mutable num = 0
    let button = new Button (ustr "Click me!", true, Clicked=System.Action (increment(&num)),  X=Pos.At(2), Y=Pos.At(1))
    let top = Application.Top
    let win = new Window (ustr "Click Game", X=Pos.At(0), Y=Pos.At(1), Width=Dim.Fill(), Height=Dim.Fill())
    top.Add (buildMenu())
    top.Add (button)
    top.Add (win)
    Application.Run ()

    0 // return an integer exit code
