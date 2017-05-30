namespace Fable.Import

open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Moment

module MomentRange = 
    type [<StringEnum>] Interval = | Year | Quarter | Month | Week | Day | Hour | Minute | Second
    type [<StringEnum>] DateMeasurment = | Years | Months |  Weeks |  Days |  Hours |  Minutes |  Seconds

    type OverlapsOption(adjacent: bool) = 
        member this.adjacent = adjacent
        new() = OverlapsOption(false)

    type ContainsOption(exclusive: bool) = 
        member this.exclusive = exclusive
        new() = ContainsOption(false)

    type ByOption(exclusive: bool, step: int) = 
        member this.exclusive = exclusive
        member this.step = step
        new () = ByOption(false, 1)

    type [<AllowNullLiteral>][<Import("DateRange","moment-range")>] DateRange(s:Moment, e:Moment) = 
        [<Emit("$0.start{{=$1}}")>]
        member this.Start with get(): Moment = jsNative and set(m: Moment): unit = jsNative
        [<Emit("$0.end{{=$1}}")>]
        member this.End with get(): Moment = jsNative and set(m: Moment): unit = jsNative
        member this.adjacent(other:DateRange): bool = jsNative
        member this.add(other:DateRange): DateRange = jsNative
        member this.by(interval:Interval, options:ByOption): seq<Moment> = jsNative
        member this.byRange(interval:Interval, options: ByOption): seq<Moment> = jsNative
        member this.center(): Moment = jsNative
        member this.clone(): DateRange = jsNative
        member this.contains(other: DateRange, options: ContainsOption): bool = jsNative
        member this.diff(unit: DateMeasurment, rounded: bool) : float = jsNative
        member this.duration(unit: DateMeasurment, rounded: bool): float = jsNative
        member this.intersect(other: DateRange): DateRange option = jsNative
        member this.isEqual(other: DateRange): bool = jsNative
        member this.isSame(other: DateRange): bool = jsNative
        member this.overlaps(other: DateRange, options: OverlapsOption):  DateRange = jsNative
        member this.reverseBy(interval: Interval, options: ByOption): seq<Moment> = jsNative
        member this.reverseByRange(interval: Interval, options: ByOption): seq<Moment> = jsNative
        member this.substract(others: DateRange): DateRange list = jsNative
        member this.toDate(): DateTime list = jsNative
        member this.toString(): string = jsNative
        member this.valueOf(): Moment = jsNative
        