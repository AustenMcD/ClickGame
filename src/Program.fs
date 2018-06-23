// Learn more about F# at http://fsharp.org

open System
open Terminal.Gui
open NStack
open Terminal.Gui

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

type StateContainer() =
    let mutable counter = 0
    member this.IncCounter() =
        counter <- counter + 1
    member this.GetCounter() =
        counter

let numBox(st:StateContainer) =
    let numStr = st.GetCounter().ToString()
    MessageBox.Query(50, 7, "Count:", numStr, "ok")
    |>ignore

[<EntryPoint>]
let main argv =

    let state = new StateContainer()
    let incState () =
        state.IncCounter()

    let DealWithButton() =
        incState()
        numBox(state)    

    Application.Init ()
    let button = new Button (ustr "Click me!", true, Clicked=System.Action (DealWithButton), X=Pos.At(2), Y=Pos.At(2))
    let top = Application.Top
    let win = new Window (ustr "Click Game", X=Pos.At(0), Y=Pos.At(1), Width=Dim.Fill(), Height=Dim.Fill())
    top.Add (buildMenu())
    top.Add (win)
    top.Add (button)
    Application.Run ()

    0 // return an integer exit code
