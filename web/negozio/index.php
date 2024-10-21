<!DOCTYPE html>
<html>

<head>
</head>

<body>
  <form>

    <style>
      .canzoni {
        overflow: auto;
        width: 100%;
      }

      .canzoni table {
        border: 1px none #dededf;
        height: 100%;
        width: 100%;
        table-layout: fixed;
        border-collapse: collapse;
        border-spacing: 1px;
        text-align: left;
      }

      .canzoni caption {
        caption-side: top;
        text-align: left;
      }

      .canzoni th {
        border: 1px none #dededf;
        background-color: #eceff1;
        color: #000000;
        padding: 5px;
      }

      .canzoni td {
        border: 1px none #dededf;
        background-color: #ffffff;
        color: #000000;
        padding: 5px;
      }
    </style>
    <div class="canzoni" role="region" tabindex="0">
      <table>
        <thead>
          <tr>
            <th>Titolo</th>
            <th>Link</th>
          </tr>
        </thead>
        <tbody>
          <?php
            $canzoni = array(
              "prova" => "ok",
              "asdasd" => "a"
            );
            foreach ($arr as &$value) {
                $value = $value * 2;
            }
            unset($value);
          ?>

          <tr>
            <td>canzone1</td>
            <td>link1</td>
          </tr>

        </tbody>
      </table>
    </div>
  </form>
</body>

</html>