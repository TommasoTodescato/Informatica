<!DOCTYPE html>

<html>

<body>
    <?php
    function splitConsVowels($word)
    {
        $cons = $vow = "";
        $vowels = ["A", "E", "I", "O", "U"];

        foreach (str_split($word) as $i) {
            if (in_array(strtoupper($i), $vowels)) {
                $vow .= $i;
            } else {
                $cons .= $i;
            }
        }
        return [$cons, $vow];
    }

    function getSurname($surname)
    {
        $result = $surname;
        $i = 0;

        if (strlen($surname) < 3) {
            $result .= "X";
        } else if (strlen($surname) > 3) {
            $result = splitConsVowels($surname)[0];
            if (strlen($result) > 3) {
                $result = substr($result, 0, 3);
            }
            while (strlen($result) < 3) {
                $result .= splitConsVowels($surname)[1][$i] ?? '';
                $i++;
            }
        }
        return strtoupper($result);
    }

    function getName($name)
    {
        $result = $name;
        $i = 0;

        if (strlen($name) < 3) {
            $result .= "X";
        } else if (strlen($name) > 3) {
            $result = splitConsVowels($name)[0];
            if (strlen($result) > 3) {
                $result = $result[0] . $result[2] . $result[3];
            }
            while (strlen($result) < 3) {
                $result .= splitConsVowels($name)[1][$i] ?? '';
                $i++;
            }
        }
        return strtoupper($result);
    }

    function get_date($date)
    {
        $months = [
            "01" => "A",
            "02" => "B",
            "03" => "C",
            "04" => "D",
            "05" => "E",
            "06" => "H",
            "07" => "L",
            "08" => "M",
            "09" => "P",
            "10" => "R",
            "11" => "S",
            "12" => "T"
        ];
        $result = substr($date, 2, 2);
        $result .= $months[substr($date, 5, 2)];
        return $result;
    }

    function getDaySex($date, $isFemale)
    {
        $result = substr($date, 8, 2);
        if ($isFemale) {
            $result += 40;
        }
        return str_pad($result, 2, '0', STR_PAD_LEFT);
    }

    function getPlace($place)
    {
        return $place;
    }

    function getControlCode($incompleteCode)
    {
        $sum = 0;
        $evenTable = [
            '0' => 0,
            '1' => 1,
            '2' => 2,
            '3' => 3,
            '4' => 4,
            '5' => 5,
            '6' => 6,
            '7' => 7,
            '8' => 8,
            '9' => 9,
            'A' => 0,
            'B' => 1,
            'C' => 2,
            'D' => 3,
            'E' => 4,
            'F' => 5,
            'G' => 6,
            'H' => 7,
            'I' => 8,
            'J' => 9,
            'K' => 10,
            'L' => 11,
            'M' => 12,
            'N' => 13,
            'O' => 14,
            'P' => 15,
            'Q' => 16,
            'R' => 17,
            'S' => 18,
            'T' => 19,
            'U' => 20,
            'V' => 21,
            'W' => 22,
            'X' => 23,
            'Y' => 24,
            'Z' => 25
        ];
        $oddTable = [
            "C" => 5,
            "D" => 7,
            "E" => 9,
            "F" => 13,
            "G" => 15,
            "1" => 0,
            "6" => 15,
            "H" => 17,
            "I" => 19,
            "J" => 21,
            "K" => 2,
            "L" => 4,
            "2" => 5,
            "7" => 17,
            "M" => 18,
            "N" => 20,
            "O" => 11,
            "P" => 3,
            "Q" => 6,
            "3" => 7,
            "8" => 19,
            "R" => 8,
            "S" => 12,
            "T" => 14,
            "U" => 16,
            "V" => 10,
            "4" => 9,
            "9" => 21,
            "W" => 22,
            "X" => 25,
            "Y" => 24,
            "Z" => 23,
            "0" => 1,
            "5" => 13,
            "A" => 1,
            "B" => 0
        ];
        $alphaTable = [
            0 => "A",
            1 => "B",
            2 => "C",
            3 => "D",
            4 => "E",
            5 => "F",
            6 => "G",
            7 => "H",
            8 => "I",
            9 => "J",
            10 => "K",
            11 => "L",
            12 => "M",
            13 => "N",
            14 => "O",
            15 => "P",
            16 => "Q",
            17 => "R",
            18 => "S",
            19 => "T",
            20 => "U",
            21 => "V",
            22 => "W",
            23 => "X",
            24 => "Y",
            25 => "Z"
        ];

        for ($i = 0; $i < 15; $i++) {
            if ($i % 2 === 0) {
                $sum += $oddTable[$incompleteCode[$i]];
            } else {
                $sum += $evenTable[$incompleteCode[$i]];
            }
        }
        $result = $sum % 26;
        return $alphaTable[$result];
    }

    if ($_SERVER['REQUEST_METHOD'] === 'POST') {
        $surname = $_POST['surname'];
        $name = $_POST['name'];
        $birthplace = $_POST['birthplace'];
        $sex = $_POST['sex'] === 'F';
        $birthdate = $_POST['birthdate'];

        $result = getSurname($surname) . getName($name) . get_date($birthdate) . getDaySex($birthdate, $sex) . getPlace($birthplace);
        $result .= getControlCode($result);
        echo $result;
    }
    ?>

</body>

</html>