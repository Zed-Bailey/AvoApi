# Avo Api
This project is an api built as a small weekend project on top of this wonderful dataset found on kaggle [https://www.kaggle.com/datasets/neuromusic/avocado-prices](https://www.kaggle.com/datasets/neuromusic/avocado-prices)


## Running
1. clone repo and cd into it
2. `dotnet ef database update` (will create `app.db` and apply the migrations)
3. `dotnet run`

## Api
The Api was built using ASP.NET core + Entity framework.

Upon initial application load if there are no records in the DB then the `avocado.csv` file is read and seeded it's records seeded into the DB

### Api Endpoints
endpoints can be viewed at the following github pages site: [https://zed-bailey.github.io/AvoApi/#/](https://zed-bailey.github.io/AvoApi/#/)

## Improvements
- adding tests
- more endpoints for some of the other columns in the dataset
- an endpoint to create avocado sale/price predictions using linear regression
