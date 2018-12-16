module Fable.Helpers.FixedDataTable

open Fable.Core
open Fable.Import
open Fable.Import.JS
open Fable.Import.React
open Fable.Core.JsInterop
open React.Props
open System

let inline rtEl<'P when 'P :> IHTMLProp> (a:ComponentClass<'P>) (b:IHTMLProp list) c = Fable.Helpers.React.from a (keyValueList CaseRules.LowerFirst b |> unbox) c


type TableProps =
    | Width of int
    | Height of int
    | MaxHeight of int
    | OwnerHeight of int
    | OverflowX of obj
    | OverflowY of obj
    | RowsCount of int
    | RowHeight of int
    | RowHeightGetter of Function
    | RowClassNameGetter of Function
    | GroupHeaderHeight of int
    | HeaderHeight of int
    | FooterHeight of int
    | ScrollLeft of int
    | ScrollToColumn of int
    | ScrollTop of int
    | ScrollToRow of int
    | OnScrollStart of Function
    | OnScrollEnd of Function
    | OnContentHeightChange of Function
    | OnRowClick of Function
    | OnRowDoubleClick of Function
    | OnRowMouseDown of Function
    | OnRowMouseEnter of Function
    | OnRowMouseLeave of Function
    | OnColumnResizeEndCallback of Function
    | IsColumnResizing of bool  //ignore
    interface Fable.Helpers.React.Props.IHTMLProp


type ColumnProps =
    | Align of string
    | Fixed of bool
    | Header of U3<string,ReactElement,Function>
    | Cell of U3<string,ReactElement,Function>
    | Footer of U3<string,ReactElement,Function>
    | ColumnKey of string
    | Width of int
    | MinWidth of int
    | MaxWidth of int
    | FlexGrow of float
    | IsResizable of bool
    | AllowCellsRecycling of bool
    interface Fable.Helpers.React.Props.IHTMLProp


type CellProps =
    | Height of int
    | Width of int
    | ColumnKey of string
    interface Fable.Helpers.React.Props.IHTMLProp



let Table = importMember<ComponentClass<IHTMLProp>> "fixed-data-table-2"

let Cell = importMember<ComponentClass<IHTMLProp>> "fixed-data-table-2"

let Column = importMember<ComponentClass<IHTMLProp>> "fixed-data-table-2"

let inline fbTable b c = rtEl Table b c

let inline fbColumn b c = rtEl Column b c 

let inline fbCell b c = rtEl Cell b c
