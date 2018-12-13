package com.erebe.question24;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.view.View;

public class QuestionView extends View {
    private Paint paint = new Paint();
    float cx, cy, radius, sw;

    public QuestionView(Context contex) {
        super(contex);

        paint.setColor(Color.BLUE);
        paint.setStyle(Paint.Style.STROKE);
        paint.setStrokeWidth(3);
    }
/* Nice Drawing
    @Override
    protected void onDraw(Canvas canvas) {
        sw = canvas.getHeight() < canvas.getWidth() ? canvas.getHeight() : canvas.getWidth();
        radius = sw * 0.5f;
        cx = canvas.getWidth() * 0.5f;
        cy = canvas.getHeight() * 0.5f;
        canvas.translate(cx, cy);
        DrawCircle(canvas);
        DrawTriangle(canvas);
        canvas.rotate(60);
        DrawTriangle(canvas);
        canvas.rotate(-60);
    }

    private void DrawCircle(Canvas canvas)
    {
        canvas.save();
        canvas.drawCircle(0,0,radius,paint);
        canvas.restore();
    }

    private void DrawTriangle(Canvas canvas)
    {
        canvas.save();
        canvas.translate(0, radius);
        canvas.scale(1,-1);
        canvas.rotate(30);
        canvas.drawLine(0,0,0,radius * 1.75f,paint);
        canvas.rotate(-60);
        canvas.drawLine(0,0,0,radius * 1.75f,paint);
        canvas.translate(0, radius* 1.75f);
        canvas.rotate(120);
        canvas.drawLine(0,0,0,radius * 1.75f,paint);
        canvas.restore();
    }
    */

    @Override
    protected void onDraw(Canvas canvas) {
        float sw = canvas.getHeight() < canvas.getWidth() ? canvas.getHeight() : canvas.getWidth();
        radius = sw * 0.5f;
        cx = canvas.getWidth() * 0.5f;
        cy = canvas.getHeight() * 0.5f;
        canvas.translate(cx, cy);
        DrawCircle(canvas);
        DrawTriangle(canvas);
        canvas.rotate(90);
        DrawTriangle(canvas);
        canvas.rotate(90);
        DrawTriangle(canvas);
        canvas.rotate(90);
        DrawTriangle(canvas);
    }

    private void DrawCircle(Canvas canvas)
    {
        canvas.save();
        canvas.drawCircle(0,0,radius,paint);
        canvas.restore();
    }

    private void DrawTriangle(Canvas canvas)
    {
        canvas.save();
        canvas.translate(0, radius);
        canvas.scale(1,-1);
        canvas.rotate(45);
        canvas.drawLine(0,0,0,radius,paint);
        canvas.rotate(-90);
        canvas.drawLine(0,0,0,radius,paint);
        canvas.translate(0, radius);
        canvas.rotate(135);
        canvas.drawLine(0,0,0,radius,paint);
        canvas.restore();
    }

}
