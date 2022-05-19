# bkw.auto
This is currently an API focused solution. Right click `bkw.auto.api` and set it as the default project. Press `F5` to run the api

## bkw.auto.interfaces
This experimetal vehicle modeling concept is designed to allow a dealership to show 4 popular types (i.e. [VehicleKind](bkw.auto/bkw.auto.interfaces/VehicleKind.cs)) of cars for sale, and available options for those cars. 

Initially the modeling of the car was conceived as a long list of [IVehicleOption](bkw.auto/bkw.auto.interfaces/IVehicleOption.cs) objects, but to aid a possible UI design, I decided to group options into smaller [IVehicleOptionModel](bkw.auto/bkw.auto.interfaces/IVehicleOptionModel.cs)s of options centered around `DriveTrain`, `Interior` and `Exterior`

I can imagine a UI implementation binding to an instance of [IVehicle](bkw.auto/bkw.auto.interfaces/IVehicle.cs) as a kind of ViewModel - and present it's available options for DriveTrain, Interior and Exterior on separate tabs or dedicatd DOM sections.

The [IVehicleOptionModel](bkw.auto/bkw.auto.interfaces/IVehicleOptionModel.cs) features two collections, one for explaining all the available options for the given [VehicleKind](bkw.auto/bkw.auto.interfaces/VehicleKind.cs), and another for holding actual selections that the user could make and submit for a possible quote or query for availablity. In a more mature solution, I might move the user-selection business into in a dedicated ViewModel library - but I believe this simplicity for now is OK.

## bkw.auto.biz
In this library I created hard implemenations of [IVehicleOptionModel](bkw.auto/bkw.auto.interfaces/IVehicleOptionModel.cs):
1. [drivetrains/HeavyDriveTrain](bkw.auto/bkw.auto.biz/drivetrains/HeavyDriveTrain.cs) 
2. [drivetrains/StandardDriveTrain](bkw.auto/bkw.auto.biz/drivetrains/StandardDriveTrain.cs)
3. [exterior/FactoryExterior](bkw.auto/bkw.auto.biz/exterior/FactoryExterior.cs)
4. [exterior/AftermarketExterior](bkw.auto/bkw.auto.biz/exterior/AftermarketExterior.cs)
5. [interior/DeluxeInterior](bkw.auto/bkw.auto.biz/interior/DeluxeInterior.cs)
6. [interior/StandardInterior](bkw.auto/bkw.auto.biz/interior/StandardInterior.cs)

The above option models derive from a [common base class](bkw.auto/bkw.auto.biz/BaseOptionModel.cs) in order to share common utility logic e.g. `ToString()`

I also created a hard instance of `IVehicle`, per each `VehicleKind` - these each feature a static `BuildCar()` factory method.

1. [EconomyCar](bkw.auto/bkw.auto.biz/EconomyCar.cs)
2. [SportsCar](bkw.auto/bkw.auto.biz/SportsCar.cs)
3. [TruckCommercial](bkw.auto/bkw.auto.biz/TruckCommercial.cs)
4. [TruckPickup](bkw.auto/bkw.auto.biz/TruckPickup.cs)

We can then implement the desired specialty options within each kind of vehicle class. For example: the `EnconomyCar` employs an instance of `StandardDriveTrain` while the `TruckCommerical` has a `HeavyDriveTrain`. The `SportsCar` has a `DeluxeInterior` and `AftermarketExterior` whereas some of the other vehicles have standard/factory options.

There is a `bkw.auto.api.test` project for testing out some of the logic in this `bkw.auto.biz` library

## bkw.auto.api
Most of my professional experience is with ASP.NET WebAPI 2 - and manually adding Swashbuckle into the mix (with a little pain and suffering on the side fiddling with an EDMX model).  I thought I'd give the dotnet 6 webapi template a whirl - WHAT A DIFFERENCE - and the integration of the Swagger UI is already a done deal!
This Web API can serve up a list of Vehicle options, as well as complete instances of IVehicle.

There is currently no database, and the options are loaded in memory by a [CompiledVehicleOptionsProvider](bkw.auto/bkw.auto.provider/CompiledVehicleOptionsProvider.cs) (which is also used in the `bkw.auto.biz.tests` project)