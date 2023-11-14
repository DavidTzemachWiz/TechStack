import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
    //Define array of objects for the stages of the test (Ramp Up/Down)
    stages: [
        {//Ramp up_1: K6 will increase the number of users from 0 to 10k in 1 minute
            duration: '1M',
            target: 10000
        },
      
         {//Ramp down: K6 will decrease the number of users to 0
            duration: '1m',
            target: 0
        }
    ],
}

//Check Smoke tests on main and sub sites
export default function () {
    http.get('https://test.k6.io');
    sleep(1);
}