import http from 'k6/http';
import { sleep } from 'k6';
import { Counter } from 'k6/metrics';//Import the k6/metrics module.

export const options = {
    vus: 5,
    duration: '5s',
    thresholds: {
        http_req_duration: ['p(95)<250'],
        my_counter: ['count>10']
    }
}

//the following creates a custom trend. The object in the script is called myTrend, 
//and its metric appears in the results output as waiting_time.
let myCounter = new Counter('my_counter');//Step 2

export default function () {
    const res = http.get('https://test.k6.io/');
    myCounter.add(1);//In the VU iteration code, use the add method to take a measurement.
    sleep(2);
}
