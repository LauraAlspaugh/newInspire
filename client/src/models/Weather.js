export class Weather{
    constructor(data){
        this.weather = data.main.temp - 273.15 || 0
        this.id = data.coord.id
        this.main = data.main
        this.visibility = data.visibility
        this.wind = data.wind
        this.clouds = data.clouds
        this.sys = data.sys
        this.name = data.name
        this.timezone = data.timezone

    }
}
const weatherData = {
    "coord": {
        "lon": -116.2035,
        "lat": 43.6135
    },
    "weather": {
        "0": {
            "id": 803,
            "main": "Clouds",
            "description": "broken clouds",
            "icon": "04n"
        },
        "icon": "https://openweathermap.org/img/wn/undefined.png"
    },
    "base": "stations",
    "main": {
        "temp": 271.87,
        "feels_like": 268.54,
        "temp_min": 271.14,
        "temp_max": 273.16,
        "pressure": 1024,
        "humidity": 87
    },
    "visibility": 10000,
    "wind": {
        "speed": 2.57,
        "deg": 130
    },
    "clouds": {
        "all": 75
    },
    "dt": 1704763184,
    "sys": {
        "type": 2,
        "id": 2043419,
        "country": "US",
        "sunrise": 1704727060,
        "sunset": 1704759879
    },
    "timezone": -25200,
    "id": 5586437,
    "name": "Boise",
    "cod": 200,
    "origin": "https://openweathermap.org"
}