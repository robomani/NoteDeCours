package com.erebe.question23;

import android.app.Activity;
import android.graphics.Color;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class MainActivity extends Activity {
    private String m_CurrentColor = "-1";
    public Button btn_Red, btn_Blue;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        btn_Red = findViewById(R.id.btn_Rouge);
        btn_Blue = findViewById(R.id.btn_Bleu);
        btn_Red.setBackgroundColor(Color.parseColor("#ff0000"));
        btn_Blue.setBackgroundColor(Color.parseColor("#0000ff"));


        btn_Blue.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ChangeColor("#0000ff");
            }
        });
        btn_Red.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ChangeColor("#ff0000");
            }
        });
    }

    @Override
    protected void onSaveInstanceState(Bundle outState) {
        super.onSaveInstanceState(outState);
        outState.putString("CurrentColor" , m_CurrentColor);
    }

    public void ChangeColor(String i_Color)
    {
        m_CurrentColor = i_Color;
        btn_Blue.setBackgroundColor(Color.parseColor(i_Color));
        btn_Red.setBackgroundColor(Color.parseColor(i_Color));
    }

    @Override
    protected void onRestoreInstanceState(Bundle savedInstanceState) {
        super.onRestoreInstanceState(savedInstanceState);
        m_CurrentColor = savedInstanceState.getString("CurrentColor", "-1" );
        if (m_CurrentColor != "-1")
        {
            ChangeColor(m_CurrentColor);
        }
        else
        {
            btn_Red.setBackgroundColor(Color.parseColor("#ff0000"));
            btn_Blue.setBackgroundColor(Color.parseColor("#0000ff"));
        }
    }
}
