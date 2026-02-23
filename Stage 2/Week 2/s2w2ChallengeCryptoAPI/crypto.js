//let coinObject = [];

async function lookupCoin() {
    // first build the API call string by starting with the URL
    let apiString = "https://api.coinlore.net/api/";
    const convertBtn = document.getElementById('convert-btn');
    
    // grab the user input
    let newCoin = document.getElementById("coin").value;
    
    // next add the user parameter to the string using the textbox and add / repos to the string
    apiString = apiString + "ticker/?id=" + newCoin;
    alert(apiString);
    
    // make the API call to the web service using the string 
    let response = await fetch(apiString);
    
    // now, check the status property of the response object, 200-299 is valid
    if (response.status >= 200 && response.status <= 299) {  // valid status
        
        //parse json file
        coinObject = await response.json();
        
        document.getElementById("coinInfo").innerHTML = `
        <strong>Name:</strong> ${coinObject[0].name} <br/>
        <strong>Rank:</strong> #${coinObject[0].rank} <br/>
        <strong>Current Price: </strong>${Number(coinObject[0].price_usd).toLocaleString('en-US', { style: 'currency', currency: 'USD' })} <br/>
        <strong>Market Cap:</strong> ${Number(coinObject[0].market_cap_usd).toLocaleString('en-US', { style: 'currency', currency: 'USD' })} <br/>
        <hr>
        <strong>Change (1h):</strong> ${coinObject[0].percent_change_1h}% <br/>
        <strong>Change (24h):</strong> ${coinObject[0].percent_change_24h}% <br/>
        <strong>Change (7d):</strong> ${coinObject[0].percent_change_7d}% <br/>
        <hr>
        <strong>Circulating Supply:</strong> ${Number(coinObject[0].csupply).toLocaleString()} ${coinObject[0].symbol} <br/>
        <strong>Max Supply:</strong> ${coinObject[0].msupply ? Number(coinObject[0].msupply).toLocaleString() : "Unlimited"} <br/>
        `;
        
        convertBtn.classList.remove('d-none');
        
    } else {            // invalid status
        // Handle errors
        alert("Error accessing API, status: " + response.status + ": " + response.statusText);

    } 
    return true;
}