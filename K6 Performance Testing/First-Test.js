//Import http so we can create HTTP request 
import http from 'k6/http'
import { sleep } from 'k6'

//Create an object that will specify test options
export const options ={
    vus: 10,
    duration: '10s'
}
//Create a function to create the HTTP request to server 
export default function(){
    //send http request to the server
    http.get('https://test.k6.io')
    sleep(1) //will wait 1 second prior start a new call 

}
