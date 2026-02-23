async function getForecast(){
  
  let apiString = "https://api.weather.gov/gridpoints/";
  const newCity = document.getElementById("newCity").value;
  console.log(newCity);
  let wfo;
  let x;
  let y;

  if (newCity === "Omaha"){
    wfo = "OAX";
    x = 54;
    y = 71;
  }else if (newCity === "Phoenix"){
    wfo = "PSR";
    x = 64;
    y = 61;
  }else if (newCity === "San Antonio"){
    wfo = "EWX";
    x = 80;
    y = 53;
  }
  
  apiString = apiString + wfo + "/" + x + "," + y + "/forecast";

  alert(apiString);

  let response = await fetch(apiString);
  let jsonData = await response.json();

  days=jsonData.properties.periods.length;

  document.getElementById("weatherForecast").innerHTML = "";

  document.getElementById("city").innerHTML = newCity;
  
  for (let i=0; i < days; i++){
    document.getElementById("weatherForecast").innerHTML += "<strong>" + jsonData.properties.periods[i].name + "</strong>" + ": " +
    jsonData.properties.periods[i].temperature + " Degrees" + "<br><br>Forecast: " + jsonData.properties.periods[i].shortForecast +
     "<br><br>Wind Speed: " + jsonData.properties.periods[i].windSpeed + "<br></br>" + "<img src='" + jsonData.properties.periods[i].icon + "'>" +"<br></br>";
  }

  return true;
}