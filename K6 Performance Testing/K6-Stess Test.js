import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
    //Define array of objects for the stages of the test (Ramp Up/Down)
    stages: [
        {//Ramp up: K6 will increase the number of users to 10 in 10s
            duration: '10s',
            target: 100
        },
        {//Ramp up: K6 will keep the number of users on 10
            duration: '30s',
            target: 10
        },
         {//Ramp down: K6 will decrease the number of users to 0
            duration: '10s',
            target: 0
        }
    ],
}

//Check Smoke tests on main and sub sites
export default function () {
    http.get('https://test.k6.io');
    sleep(1);
    http.get('https://test.k6.io/contact.php');
    sleep(2);
    http.get('https://test.k6.io/news.php');
    sleep(2);
}