# Fable.FixedDataTable


Fable bindings and elmish helpers for https://github.com/schrodinger/fixed-data-table-2 

To build on windows, run "fake build" after install fake cli tool globaly.

#Example Code

```fsharp
let getCell x = !!x?rowIndex :int

let makeColumn (field :FieldDef) (index :int) (viewElem :ViewElem) (ts :TypeSystem) (dispatch :ViewMsg -> unit) =
    fbColumn 
        [ColumnProps.AllowCellsRecycling(true); 
         ColumnProps.IsResizable(true); 
         ColumnProps.ColumnKey(field.Name);
         ColumnProps.Header(!!(fun _ -> text field.Name));
         ColumnProps.Cell(!!(fun x -> renderField field index (getCell(x)) viewElem.FilteredTransactions ts dispatch ));
         ColumnProps.Width(100)] 
         []

let renderTable (db :DB) (viewElem :ViewElem) (dispatch :ViewMsg -> unit) =
    let transType = match db.Types.Item("Transaction") with | Record(def) -> def | _ -> []
    fbTable 
        [TableProps.Width(100 * List.length transType);
         TableProps.Height(600);
         TableProps.RowHeight(30);
         TableProps.HeaderHeight(30);
         TableProps.RowsCount(viewElem.FilteredTransactions.Length)
         TableProps.OnColumnResizeEndCallback(!!(fun x -> dispatch ViewMsg.ResizeColumn(x?newColumnWidth ))) ] 
        (List.mapi (fun i x ->  makeColumn x i viewElem db.Types dispatch) transType)
```
This is some sample code I copied from a WIP application. 

