// neural network
// input layer - hidden layer - output layer
//     10      - HIDDEN_NODES -      4        <- number of nodes
// weights range: <min_w, max_w>
// bias range: <min_b, max_b>

class DNA {
  float hidden_weights[][];
  float hidden_bias[];
  float output_weights[][];
  float output_bias[];
  float output[];
  int hn;
  int min_w;
  int max_w;
  int min_b;
  int max_b;

  //-------------------------------------------------------------------------------------------------------
  //-------------------------------------------------------------------------------------------------------

  //constructor
  DNA() {
    hn = HIDDEN_NODES;
    hidden_weights = new float[10][hn];
    hidden_bias = new float[hn];
    output_weights = new float[hn][4];
    output_bias = new float[4];

    min_w = -1;
    max_w = 1;
    min_b = -3;
    max_b = 3;

    //randomly initializing weights and bias
    for (int i = 0; i < 10; i++)
      for (int j = 0; j < hn; j++)
        hidden_weights[i][j] = random(min_w, max_w);

    for (int i = 0; i < hn; i++)
      hidden_bias[i] = random(min_b, max_b);

    for (int i = 0; i < hn; i++)
      for (int j = 0; j < 4; j++)
        output_weights[i][j] = random(min_w, max_w);

    for (int i = 0; i < 4; i++) 
      output_bias[i] = random(min_b, max_b);
  }
  
  //-------------------------------------------------------------------------------------------------------
  //-------------------------------------------------------------------------------------------------------

  //copying constructor
  DNA(DNA d) {
    hn = HIDDEN_NODES;
    hidden_weights = new float[10][hn];
    hidden_bias = new float[hn];
    output_weights = new float[hn][4];
    output_bias = new float[4];

    //randomly initializing weights and bias
    for (int i = 0; i < 10; i++)
      for (int j = 0; j < hn; j++)
        hidden_weights[i][j] = d.hidden_weights[i][j];

    for (int i = 0; i < hn; i++)
      hidden_bias[i] = d.hidden_bias[i];

    for (int i = 0; i < hn; i++)
      for (int j = 0; j < 4; j++)
        output_weights[i][j] = d.output_weights[i][j];

    for (int i = 0; i < 4; i++) 
      output_bias[i] = d.output_bias[i];
  }

  //-------------------------------------------------------------------------------------------------------
  //-------------------------------------------------------------------------------------------------------

  //activation function - sigmoid
  float sigmoid(float x) {
    float result;
    result = (float) (1 / (1 + Math.exp(-x)));
    return result;
  }

  //-------------------------------------------------------------------------------------------------------
  //-------------------------------------------------------------------------------------------------------

  //calculating output by reciving inputs
  char compute(float[] wall, float[] body, float fx, float fy) {
    char result;
    float input[] = new float[10];
    float hidden[] = new float[hn];
    float output[] = new float[4];
    int temp = 0;

    input[0] = wall[0]; // 0 - NORTH
    input[1] = wall[1]; // 1 - SOUTH
    input[2] = wall[2]; // 2 - EAST
    input[3] = wall[3]; // 3 - WEST
    input[4] = body[0];
    input[5] = body[1];
    input[6] = body[2];
    input[7] = body[3];
    input[8] = fx;
    input[9] = fy;

    for (int i = 0; i < hn; i++)
      hidden[i] = 0;

    for (int i = 0; i < 4; i++)
      output[i] = 0;

    // calculating hidden nodes
    for (int i = 0; i < 10; i++)
      for (int j = 0; j < hn; j++)
        hidden[j] += (input[i] * hidden_weights[i][j]);

    for (int i = 0; i < hn; i++) {
      hidden[i] += hidden_bias[i];
      hidden[i] = sigmoid(hidden[i]);
    }

    //calculating output nodes
    for (int i = 0; i < hn; i++)
      for (int j = 0; j < 4; j++)
        output[j] += (hidden[i] * output_weights[i][j]);

    //checking max output value
    for (int i = 0; i < 4; i++) {
      output[i] += output_bias[i];
      output[i] = sigmoid(output[i]);
      if (output[temp] < output[i])
        temp = i;
    }

    switch(temp) {
    case 0:
      result = 'w';
      break;
    case 1:
      result = 's';
      break;
    case 2:
      result = 'a';
      break;
    case 3:
      result = 'd';
      break;
    default:
      result = 'w'; // default - cause result must be initialize
      break;
    }

    return result;
  }

  //-------------------------------------------------------------------------------------------------------
  //-------------------------------------------------------------------------------------------------------

  // makes new DNA (neural network) from 2 given DNAs
  void crossover(DNA d1, DNA d2) {
    int x = (10 * hn) / 2; // randomly choosing "mid" point to cut the "DNA"
    int temp = 0; // "current" sum of fitnesses

    // hiddenWeights
    for (int i = 0; i < 10; i++)
      for (int j = 0; j < hn; j++) {
        if (temp < x)
          hidden_weights[i][j] = d1.hidden_weights[i][j];
        else
          hidden_weights[i][j] = d2.hidden_weights[i][j];

        temp++;
      }

    x = hn / 2;
    temp = 0;

    // hiddenBias
    for (int i = 0; i < hn; i++) {
      if (temp < x)
        hidden_bias[i] = d1.hidden_bias[i];
      else
        hidden_bias[i] = d2.hidden_bias[i];

      temp++;
    }

    x = (hn * 4) / 2;
    temp = 0;

    // outputWeights
    for (int i = 0; i < hn; i++)
      for (int j = 0; j < 4; j++) {
        if (temp < x)
          output_weights[i][j] = d1.output_weights[i][j];
        else
          output_weights[i][j] = d2.output_weights[i][j];

        temp++;
      }

    x = 4 / 2;
    temp = 0;

    // outputBias
    for (int i = 0; i < 4; i++) {
      if (temp < x)
        output_bias[i] = d1.output_bias[i];
      else
        output_bias[i] = d2.output_bias[i];

      temp++;
    }
  }

  //-------------------------------------------------------------------------------------------------------
  //-------------------------------------------------------------------------------------------------------

  // mutates existing DNA
  void mutation() {
    float m = MUTATION_RATE;

    // hiddenWeights
    for (int i = 0; i < 10; i++)
      for (int j = 0; j < hn; j++)
        if (random(1) <= m)
          hidden_weights[i][j] = random(min_w, max_w);

    // hiddenBias
    for (int i = 0; i < hn; i++) 
      if (random(1) <= m)
        hidden_bias[i] = random(min_b, max_b);

    // outputWeights
    for (int i = 0; i < hn; i++)
      for (int j = 0; j < 4; j++)
        if (random(1) <= m)
          output_weights[i][j] = random(min_w, max_w);

    // outputBias
    for (int i = 0; i < 4; i++) 
      if (random(1) <= m)
        output_bias[i] = random(min_b, max_b);
  }

  //-------------------------------------------------------------------------------------------------------
  //-------------------------------------------------------------------------------------------------------

  void print() {
    for (float[] a : hidden_weights)
      for (float b : a)
        println(b);

    for (float a : hidden_bias)
      println(a);

    for (float[] a : output_weights)
      for (float b : a)
        println(b);

    for (float a : output_bias)
      println(a);
  }
}
