async function getGitHubUser() {

    // first build the API call string by starting with the URL
    let apiString = "https://api.github.com/repos/";
    
    // next add the user parameter to the string using the textbox and add / repos to the string
    let theNewUser = document.getElementById('newUser').value;
    let theNewRepo = document.getElementById('newRepo').value;
    apiString = apiString + theNewUser + "/" + theNewRepo + "/commits";

    alert(apiString);

    // make the API call to the web service using the string 
    let response = await fetch(apiString);
    let theNewCommits = "";

    // now, check the status property of the response object, 200-299 is valid
    if (response.status >= 200 && response.status <= 299) {  // valid status

      let jsonData = await response.json();   // a json file will fetched

      // create the user feedback with the repos and links
      for (var commits in jsonData) {
            theNewCommits += "<p>" + "\"" + jsonData[commits].commit.message + "\"" + "<br/>Updated on: " + jsonData[commits].commit.committer.date +
            " by: " + jsonData[commits].commit.author.name + "</p>";
          }

    } else {            // invalid status
      // Handle errors
        theNewCommits = "<p>Error accessing GitHub, status: " + response.status + ": " + response.statusText;
        console.log(response.status, response.statusText);
    }

    document.getElementById("theUserName").innerHTML = "";   // clear what was previously shown
    document.getElementById("theRepos").innerHTML = "";   // clear what was previously shown
    // print out the information for the user and clear the userid
    document.getElementById("theUserName").innerHTML = theNewUser + `'s most recent commits on the repo ${theNewRepo}:`;
    document.getElementById("theRepos").innerHTML = theNewCommits;
    document.getElementById('newUser').value = "";
    document.getElementById('newRepo').value = "";

    //finally scroll back to the top of the page
    window.scrollTo(0,0);
  
    return true;
  }